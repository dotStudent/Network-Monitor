using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Network_Monitor.FormHelpers
{
    public class Host //Class for Host Object List
    {
        public IPAddress IP_Address { get; set; } = null;
        public string Hostname { get; set; } = "";
        public bool? Active { get; set; } = null;
        public DateTime? First_Seen { get; set; } = null;
        public DateTime? Last_Seen { get; set; } = null;
        public DateTime? Last_Checked { get; set; } = null;
        public bool? RunningCheck { get; set; } = null;
        public int? Roundtrip { get; set; } = null;
        public int CountChecks { get; set; } = 0;
        public bool? PortOpen { get; set; } = null;
    }
    // ------------------------------------------------------------------------
    public class SortedBindingList<T> : BindingList<T>
    {
        private ListSortDirection m_sortDirection;
        private PropertyDescriptor m_propertyDescriptor;
        private bool m_isSorted;

        private const int NO_ITEM_INDEX = -1;

        // in this case, the list is not sorted, you have to call the Sort Method
        public SortedBindingList() : base()
        {

        }
        // In this case, the list is sorted
        public SortedBindingList(IEnumerable<T> enumeration)
            : base(new List<T>(enumeration))
        {
        }
        public void Sort(string propertyName, ListSortDirection sortDirection)
        {
            if (Count > 0)
            {
                PropertyDescriptor pd = System.ComponentModel.TypeDescriptor.GetProperties(this[0])[propertyName];

                ((IBindingList)this).ApplySort(pd, sortDirection);
            }
        }
        protected override bool IsSortedCore
        {
            get
            {
                return m_isSorted;
            }
        }
        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return m_sortDirection;
            }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return m_propertyDescriptor;
            }
        }
        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }
        protected override void ApplySortCore(PropertyDescriptor propertyDesciptor, ListSortDirection sortDirection)
        {
            m_isSorted = true;
            m_sortDirection = sortDirection;
            m_propertyDescriptor = propertyDesciptor;

            var comparer = createComparer(propertyDesciptor, sortDirection);

            sort(comparer);
        }
        public override void EndNew(int itemIndex)
        {
            // Check to see if the item is added to the end of the list,
            // and if so, re-sort the list.
            if (m_propertyDescriptor != null && itemIndex > 0 && itemIndex == this.Count - 1)
                ApplySortCore(m_propertyDescriptor, m_sortDirection);

            base.EndNew(itemIndex);
        }
        protected virtual IComparer<T> createComparer(PropertyDescriptor property, ListSortDirection direction)
        {
            return new PropertyDescriptorComparer<T>(property, direction);
        }

        private void sort(IComparer<T> comparer)
        {
            ((List<T>)Items).Sort(comparer);
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, NO_ITEM_INDEX));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = Count;

            for (int itemIndex = 0; itemIndex < count; itemIndex++)
            {
                T item = this[itemIndex];
                var itemValue = property.GetValue(item);
                if (itemValue.Equals(key))
                {
                    return itemIndex;
                }
            }

            return NO_ITEM_INDEX;
        }
        protected override void RemoveSortCore()
        {
            m_isSorted = false;
            m_sortDirection = base.SortDirectionCore;
            m_propertyDescriptor = base.SortPropertyCore;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, NO_ITEM_INDEX));
        }
    }
    // ------------------------------------------------------------------------
    public class PropertyDescriptorComparer<T> : IComparer<T>
    {
        // ------------------------------------------------------------------------
        private const int ASCENDING = 1;
        private const int DESCENDING = -1;

        // ------------------------------------------------------------------------
        private readonly int m_sortDirection;
        private readonly PropertyDescriptor m_propertyDescriptor;
        private readonly IComparer m_comparer;

        // ------------------------------------------------------------------------
        public PropertyDescriptorComparer(PropertyDescriptor propertyDescriptor, ListSortDirection sortDirection)
        {
            m_propertyDescriptor = propertyDescriptor;
            m_comparer = getComparerFromDescriptor();

            m_sortDirection = sortDirection == ListSortDirection.Ascending ? ASCENDING : DESCENDING;
        }

        // ------------------------------------------------------------------------
        private IComparer getComparerFromDescriptor()
        {
            Type comparerType = typeof(Comparer<>);
            Type comparerForPropertyType = comparerType.MakeGenericType(m_propertyDescriptor.PropertyType);

            return (IComparer)comparerForPropertyType.InvokeMember("Default",
                                                                     BindingFlags.GetProperty |
                                                                     BindingFlags.Public |
                                                                     BindingFlags.Static,
                                                                     null, null, null);
        }
        // ------------------------------------------------------------------------
        public int Compare(T x, T y)
        {
            object xValue = m_propertyDescriptor.GetValue(x);
            object yValue = m_propertyDescriptor.GetValue(y);

            if (xValue != null)
            {
                if (xValue.GetType() == typeof(IPAddress))
                {
                    string valueA = string.Join(".", xValue.ToString().Split('.').Select(z => Convert.ToInt32(z).ToString("000")));
                    string valueB = string.Join(".", yValue.ToString().Split('.').Select(z => Convert.ToInt32(z).ToString("000")));
                    return m_sortDirection * String.Compare(valueA, valueB);
                }
                return m_sortDirection * m_comparer.Compare(xValue, yValue);
            }
            else
            {
                return m_sortDirection * m_comparer.Compare(xValue, yValue);
            }
        }
    }
}
