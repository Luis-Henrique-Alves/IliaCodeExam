using System.Data.Common;

namespace IliaCodeTest.Repository.DbContext
{
    public interface IIliaCodeTestDbContext
    {
        DbConnection OpenConnection();
    }
}
