using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class KeyValue
    {
        private string key,
            value;

        [DisplayName("Key")]
        public string Key { get => key; set => key = value; }
        [DisplayName("Value")]
        public string Value { get => value; set => this.value = value; }
    }
}
