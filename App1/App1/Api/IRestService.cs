namespace App1.Api {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IRestService {

        List<Root> Items { get; }

        List<Root> RefreshData(string productCode);
        Task<List<Root>> RefreshDataAsync(string productCode);
    }
}