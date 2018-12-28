using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data;
using ZHD_vokzal.Model;
using ZHD_vokzal.Helpers;
using System.Windows;
using ZHD_vokzal.View;

namespace ZHD_vokzal.ViewModel
{
    public class ScheduleService : Base
    {
        DBmodel db;

        public List<Reis> allReis { get; set; }

        public List<VagonType> allTypes { get; set; }

        public RelayCommand BuyTicketCommand { get; set; }

        public ScheduleService()
        {
            BuyTicketCommand = new RelayCommand(BuyTicket, CanExecute);

            db = new DBmodel();
            db.Reis.Load();
            allReis = db.Reis.ToList();

            db.VagonType.Load();
            allTypes = new List<VagonType>(db.VagonType.AsEnumerable().Select(i => new VagonType() { Type = i.Type }).ToList());

        }

        public bool CreateBilet(Bilet bilet)
        {
            db.Bilet.Add(bilet);
            return Save();
        }

        public bool CreatePassazhir(Passazhir passazhir)
        {
            db.Passazhir.Add(passazhir);
            return Save();
        }

        Random rand = new Random();
   
        int NV;
        string VT;

        void BuyTicket(object parameter)
        {
            if (SelectedVagonType.Type == "Плацкарт") { NV = 2; VT = "Плацкарт";}
            if (SelectedVagonType.Type == "Сидячий") { NV = 3; VT = "Сидячий";}
            if (SelectedVagonType.Type == "Купе") { NV = 1; VT = "Купе"; }

            Bilet bilet = new Bilet()
            {
                FIOpassagira = _SelectedFIO,
                Passport = _SelectedPassport,
                Stoimost = rand.Next(200, 500),
                Skidka = rand.Next(0, 10),
                NumberReis = _SelectedReis.NumberReis,
                NumberVagon = NV,
                NumberMesto = Convert.ToInt16(_SelectedPlace),
                MestoType = _SelectedPlaceType,
                DateOtpravleniya = _SelectedReis.DateOtpravleniya,
                DatePribitiya = _SelectedReis.DatePribitiya,
                TimeOtpravleniya = _SelectedReis.TimeOtpravleniya,
                TimePribitiya = _SelectedReis.TimePribitiya,
                PunktOtpravleniya = _SelectedReis.Marshrut.Punkt_otpravleniya ,
                PunktPribitiya = _SelectedReis.Marshrut.Punkt_pribitiya
                };
            
            Passazhir passazhir = new Passazhir()
            {
                FIO = _SelectedFIO,
                Passport = _SelectedPassport
            };
            db.Bilet.Add(bilet);
            Save();
            var win = new Ticket(bilet);
            win.Show();
            CloseWindow();
        }
      
       /* private static readonly KeyValuePair<int, string>[]tripLengthList =
        {
            new KeyValuePair<int, string>(w)
        }*/

        string _SelectedFIO;
        public string SelectedFIO
        {
            get
            {
                return _SelectedFIO;
            }
            set
            {
                if (_SelectedFIO != value)
                {
                    _SelectedFIO = value;
                    RaisePropertyChanged("SelectedFIO");
                }
            }
        }

        string _SelectedPassport;
        public string SelectedPassport
        {
            get
            {
                return _SelectedPassport;
            }
            set
            {
                if (_SelectedPassport != value)
                {
                    _SelectedPassport = value;
                    RaisePropertyChanged("SelectedPassport");
                }
            }
        }

        Reis _SelectedReis;
        public Reis SelectedReis
        {
            get
            {
                return _SelectedReis;
            }
            set
            {
                if (_SelectedReis != value)
                {
                    _SelectedReis = value;
                    RaisePropertyChanged("SelectedReis");
                }
            }
        }

        string _SelectedPlace;
        public string SelectedPlace
        {
            get
            {
                return _SelectedPlace;
            }
            set
            {
                if (_SelectedPlace != value)
                {
                    _SelectedPlace = value;
                    RaisePropertyChanged("SelectedPlace");
                }
            }
        }

        string _SelectedPlaceType;
        public string SelectedPlaceType
        {
            get
            {
                return _SelectedPlaceType;
            }
            set
            {
                if (_SelectedPlaceType != value)
                {
                    _SelectedPlaceType = value;
                    RaisePropertyChanged("SelectedPlaceType");
                }
            }
        }

        VagonType _SelectedVagonType;
        public VagonType SelectedVagonType
        {
            get
            {
                return _SelectedVagonType;
            }
            set
            {
                if (_SelectedVagonType != value)
                {
                    _SelectedVagonType = value;
                    RaisePropertyChanged("SelectedVagonType");
                }
            }
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        bool CanExecute(object parameter)
        {
            return ((SelectedReis != null) && (SelectedFIO != null) && (SelectedPassport != null));
        }

    }
}