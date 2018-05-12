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
        private ComponentaService _componentaService;
        private GrupaDeSangeService _grupaDeSangeService;
        private PacientService _pacientService;
        private MedicService _medicService;


        private AppService ()
        {
            _donatieService = new DonatieService();
            _institutieService = new InstitutieAsociataService();
            _donatorService = new DonatorService();
            _componentaService = new ComponentaService();

            _cerereService = new CerereMedicPacientService();
            _grupaDeSangeService = new GrupaDeSangeService();
            _pacientService = new PacientService();
            _medicService = new MedicService();
        }

        public MedicService MedicService
        {
            get { return _medicService; }
        }

        public ComponentaService ComponentaService
        {
            get { return _componentaService; }
        }

        public DonatieService DonatieService
        {
            get { return _donatieService; }
        }

        public PacientService PacientService
        {
            get { return _pacientService; }
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

        public GrupaDeSangeService GrupaDeSangeService
        {
            get { return _grupaDeSangeService; }
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
