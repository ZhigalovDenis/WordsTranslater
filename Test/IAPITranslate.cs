using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	public interface IAPITranslate<T0, T1> where T0: class
	{
		Task<T1> SetAPI(T0 api, T1 word);
	}
}
