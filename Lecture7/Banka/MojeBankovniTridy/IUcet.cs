using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeBankovniTridy
{
	public interface IUcet
	{
		double Zustatek { get; }
		string Vlastnik { get; }
	}
}
