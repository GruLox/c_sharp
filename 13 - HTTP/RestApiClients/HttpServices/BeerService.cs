
using Models;

namespace BeerApp;

public class BeerService: BaseService
{
    public static async Task<Beer> GetByIdAsync(int id)
    {
        var beer = await SendGetRequestAsync<Beer>("api/beer/get-all", id);
        return beer;
    }
    

}
