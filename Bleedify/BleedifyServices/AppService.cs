using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleedifyServices
{
    public class AppService
    {
        private static AppService _instance;
        private DonatieService _donatieService;

        private AppService ()
        {
            _donatieService = new DonatieService();
        }

        public DonatieService DonatieService
        {
            get { return _donatieService; }
        }

        public static AppService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AppService();
                }
                return _instance;
            }
        }
    }
}
