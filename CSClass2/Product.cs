using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSClass2
{
    class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public int CompareTo(Product other)
        {
            // 리턴값 : 0 - 같다, 음수 - 작다, 양수 - 크다

            /*
            int result = 0;
            if(this.Price < other.Price)
            {
                result = -1;
            }else if(this.Price > other.Price)
            {
                result = 1;
            }

            return result;
            */

            // 위의 코드와 같은 의미
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return Name + " : " + Price + "원";
        }
    }
}
