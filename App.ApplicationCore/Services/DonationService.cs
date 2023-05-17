using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class DonationService : Service<Donation>, IDonationService
    {
        public DonationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public int GetTotalDon(DateTime start, DateTime end)
        {
            return GetAll()
                .Where(e => e.Date.Date >= start.Date && e.Date.Date <= end.Date)
                .Sum(e => e.Amount);
        }
    }
}
