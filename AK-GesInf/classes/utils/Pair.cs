using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AK_GesInf.classes.utils
{
    /**
     * Pair class to provide a mutable tuple
     * 
     * K the key
     * V the value
     **/

    public class Pair<K, V>
    {
        private K key;
        private V value;

        public Pair(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public K Key
        {
            get { return key; }
            set { key = value; }
        }

        public V Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return string.Format("Key: {0}, Value: {1}", key, value);
        }
    }
}