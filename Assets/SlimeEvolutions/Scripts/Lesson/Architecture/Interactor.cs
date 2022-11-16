
namespace SlimeEvolutions.Lesson.Architecture
{
    public class Interactor
    {
        public virtual void OnCreate() { } // When all interactors are created.
        public virtual void Initialize() { }
        public virtual void OnStart() { }
    }
}
