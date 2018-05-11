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
        private CerereMedicPacientService _cerereService;

        private AppService ()
        {
            _donatieService = new DonatieService();
            _cerereService = new CerereMedicPacientService();
        }

        public DonatieService DonatieService
        {
            get { return _donatieService; }
        }

        public CerereMedicPacientService CerereService
        {
            get { return _cerereService; }
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
