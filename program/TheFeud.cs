using IField;
using McDroid;

namespace IField
{
    internal class Sheep
    {
        public Sheep() { }
    }

    internal class Pig
    {
        public Pig() { }
    }
}

namespace McDroid
{
    internal class Cow
    {
        public Cow() { }
    }

    internal class Pig
    {
        public Pig() { }
    }
}
class TheFeud
{
    public TheFeud() 
    {
        Sheep sheep = new Sheep();
        IField.Pig pig = new IField.Pig();

        Cow cow = new Cow();
        McDroid.Pig piggy = new McDroid.Pig();
    }
}