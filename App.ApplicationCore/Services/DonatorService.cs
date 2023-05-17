using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class DonatorService : Service<Donator>,IDonatorService
    {

        public DonatorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public IEnumerable<Donator> GetDonatorsNoKafala()
        {
            return GetMany(
                e => e.Donations.Count()>0 && e.Kafalas.Where(
                    k => (k.StartDate.Date>DateTime.Now.Date) || (k.EndDate.Date<DateTime.Now.Date)
                    ).Count()==0 );
        }
    }
}
