
namespace Lucid.Framework
{
    public class Position
        : IPositionComponent
    {
        public System.Drawing.Size RectSize
        {
            get;
            set;
        }

        Vector IPositionComponent.Position
        {
            get;
            set;
        }
    }
}
