using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tt_qaa_CSharp
{
    public class Optional<T>
    {
        private T value;

        public Optional(T value){
            this.value = value;
        }

        public bool hasValue() {
            return value != null;
        }

        public T getValue(){
            return value;
        }
        

    }

}
