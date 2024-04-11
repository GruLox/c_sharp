namespace BeerApp;

public static class AppState
{
    private static Beer _selectedBeer;

    public static void SetBeer(Beer beer) => _selectedBeer = beer;

    public static void Clear() => _selectedBeer = null;

    public static Beer GetBeer() => _selectedBeer;

    public static void Update(Beer beer)
    {
        _selectedBeer.Image = string.IsNullOrEmpty(beer.Image) ? 
                                  _selectedBeer.Image : 
                                  beer.Image;

        _selectedBeer.Name = string.IsNullOrEmpty(beer.Name) ?
                                  _selectedBeer.Name :
                                  beer.Name;

        _selectedBeer.Price = string.IsNullOrEmpty(beer.Price) ?
                                  _selectedBeer.Price :
                                  beer.Price;
    }
}
