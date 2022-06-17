using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQubeExperiments
{
    public interface IModelWrapper
    {
        Guid Id { get; }
        string Name { get; set; }
        IModelWrapper Parent { get; }

        T GetAncestorOrSelf<T>() where T : IModelWrapper;
    }

    public abstract class ModelWrapperBase : IModelWrapper
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IModelWrapper Parent { get; set; }

        public virtual T GetAncestorOrSelf<T> () where T : IModelWrapper
        {
            if (this is T)
                return (T)(this as IModelWrapper);

            var parent = this.Parent;
            if (parent == null)
                return default(T);

            return parent.GetAncestorOrSelf<T>();
        }
    }
}
