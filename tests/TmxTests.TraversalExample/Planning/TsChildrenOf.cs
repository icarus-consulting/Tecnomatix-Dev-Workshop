using System;
using Tecnomatix.Engineering;
using Tecnomatix.Planning;
using Yaapii.Atoms;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Scalar;

namespace TmxSmarts.Planning
{
    /// <summary>
    /// The prototype object of the given instance
    /// </summary>
    public sealed class TsChildrenOf : ListEnvelope<ITxObject>
    {
        /// <summary>
        /// The prototype object of the given instance
        /// </summary>
        public TsChildrenOf(ITxPlanningObject planningObject, params string[] fields) :this(
            () => planningObject,
            fields
        )
        { }

        /// <summary>
        /// The prototype object of the given instance
        /// </summary>
        public TsChildrenOf(Func<ITxPlanningObject> planningObject, params string[] fields) : this(
            ScalarOf.New(planningObject),
            fields
        )
        { }

        /// <summary>
        /// The prototype object of the given instance
        /// </summary>
        public TsChildrenOf(IScalar<ITxPlanningObject> planningObject, params string[] fields) : base(() =>
        {

            var manager = new Tecnomatix.Engineering.Utilities.TxEmsTraversalManager();
            var instance = manager["tr::children"];
            instance.SetRootObject(planningObject.Value());
            instance.SetAttributes(fields);
            instance.SetPath("children");
            instance.CacheFieldsValues = true;
            manager.Traverse(includeParent: false, includeChildrenInTraverse: false);
            var data = instance.GetTraversalObjectData(planningObject.Value());
            return data.GetRelationFieldValues("children");
        }, live: false
        )
        { }
    }
}
