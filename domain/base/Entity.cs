using System;

namespace domain.generics
{
    public class Entity
    {
        public virtual Int32 Key { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            if (this == obj || ((Entity)obj).Key.Equals(Key))
                return true;
            
            return base.Equals (obj);
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Key.GetHashCode();
            return hash;
        }
    }
}