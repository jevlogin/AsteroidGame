using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Storage<TItem>
    {
        private readonly List<TItem> _Items = new List<TItem>();

        public void Add(TItem Item)
        {
            if (_Items.Contains(Item))
            {
                return;
            }
            _Items.Add(Item);
        }
        public bool Remove(TItem Item)
        {
            return _Items.Remove(Item);
        }
    }

    class Dekanat : Storage<Student>
    {

    }
}
