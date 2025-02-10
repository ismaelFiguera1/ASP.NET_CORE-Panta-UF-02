namespace Cistell_de_la_compra.Models
{
    public class Cistell
    {

        public List<ElementCistell> Elements { get; set; } = new List<ElementCistell>();

        // No ho faig estatic perqu cada usuari te que tindrer la seva cesta, si ho faig tots els usuaris farien servir la mateixa cesta i hi haria error de logica
    }
}
