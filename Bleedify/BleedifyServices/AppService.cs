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
        private DonatorService _donatorService;
        private InstitutieAsociataService _institutieService;
        private CerereMedicPacientService _cerereService;

        private AppService ()
        {
            _donatieService = new DonatieService();
            _institutieService = new InstitutieAsociataService();
            _donatorService = new DonatorService();
            _cerereService = new CerereMedicPacientService();
        }

        public DonatieService DonatieService
        {
            get { return _donatieService; }
        }

        public InstitutieAsociataService InstitutieAsociataService
        {
            get { return _institutieService; }
        }

        public DonatorService DonatorService
        {
            get { return _donatorService; }
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
