using Apps.DataProcessor.DataAccess.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.DataProcessor.DataAccess.Factories.Interfaces
{
    public interface IUserDBContextFactory
    {
        UserDBContext Create(string connectionString);
    }
}
