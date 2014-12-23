﻿ 

// -----------------------------------------------------------------------
// <autogenerated>
//    This code was generated from a template.
//
//    Changes to this file may cause incorrect behaviour and will be lost
//    if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using BrightstarDB.Client;
using BrightstarDB.EntityFramework;

using System.Text;
using System.Threading.Tasks;

namespace Hqub.Esenin.App.Model 
{
    public partial class MyEntityContext : BrightstarEntityContext {
    	
    	static MyEntityContext() 
    	{
    		var provider = new ReflectionMappingProvider();
    		provider.AddMappingsForType(EntityMappingStore.Instance, typeof(Hqub.Esenin.App.Model.IPoem));
    		EntityMappingStore.Instance.SetImplMapping<Hqub.Esenin.App.Model.IPoem, Hqub.Esenin.App.Model.Poem>();
    		provider.AddMappingsForType(EntityMappingStore.Instance, typeof(Hqub.Esenin.App.Model.IQuatrain));
    		EntityMappingStore.Instance.SetImplMapping<Hqub.Esenin.App.Model.IQuatrain, Hqub.Esenin.App.Model.Quatrain>();
    	}
    	
    	/// <summary>
    	/// Initialize a new entity context using the specified BrightstarDB
    	/// Data Object Store connection
    	/// </summary>
    	/// <param name="dataObjectStore">The connection to the BrightstarDB Data Object Store that will provide the entity objects</param>
    	public MyEntityContext(IDataObjectStore dataObjectStore) : base(dataObjectStore)
    	{
    		InitializeContext();
    	}
    
    	/// <summary>
    	/// Initialize a new entity context using the specified Brightstar connection string
    	/// </summary>
    	/// <param name="connectionString">The connection to be used to connect to an existing BrightstarDB store</param>
    	/// <param name="enableOptimisticLocking">OPTIONAL: If set to true optmistic locking will be applied to all entity updates</param>
        /// <param name="updateGraphUri">OPTIONAL: The URI identifier of the graph to be updated with any new triples created by operations on the store. If
        /// not defined, the default graph in the store will be updated.</param>
        /// <param name="datasetGraphUris">OPTIONAL: The URI identifiers of the graphs that will be queried to retrieve entities and their properties.
        /// If not defined, all graphs in the store will be queried.</param>
        /// <param name="versionGraphUri">OPTIONAL: The URI identifier of the graph that contains version number statements for entities. 
        /// If not defined, the <paramref name="updateGraphUri"/> will be used.</param>
    	public MyEntityContext(
    	    string connectionString, 
    		bool? enableOptimisticLocking=null,
    		string updateGraphUri = null,
    		IEnumerable<string> datasetGraphUris = null,
    		string versionGraphUri = null
        ) : base(connectionString, enableOptimisticLocking, updateGraphUri, datasetGraphUris, versionGraphUri)
    	{
    		InitializeContext();
    	}
    
    	/// <summary>
    	/// Initialize a new entity context using the specified Brightstar
    	/// connection string retrieved from the configuration.
    	/// </summary>
    	public MyEntityContext() : base()
    	{
    		InitializeContext();
    	}
    	
    	/// <summary>
    	/// Initialize a new entity context using the specified Brightstar
    	/// connection string retrieved from the configuration and the
    	//  specified target graphs
    	/// </summary>
        /// <param name="updateGraphUri">The URI identifier of the graph to be updated with any new triples created by operations on the store. If
        /// set to null, the default graph in the store will be updated.</param>
        /// <param name="datasetGraphUris">The URI identifiers of the graphs that will be queried to retrieve entities and their properties.
        /// If set to null, all graphs in the store will be queried.</param>
        /// <param name="versionGraphUri">The URI identifier of the graph that contains version number statements for entities. 
        /// If set to null, the value of <paramref name="updateGraphUri"/> will be used.</param>
    	public MyEntityContext(
    		string updateGraphUri,
    		IEnumerable<string> datasetGraphUris,
    		string versionGraphUri
    	) : base(updateGraphUri:updateGraphUri, datasetGraphUris:datasetGraphUris, versionGraphUri:versionGraphUri)
    	{
    		InitializeContext();
    	}
    	
    	private void InitializeContext() 
    	{
    		Poems = 	new BrightstarEntitySet<Hqub.Esenin.App.Model.IPoem>(this);
    		Quatrains = 	new BrightstarEntitySet<Hqub.Esenin.App.Model.IQuatrain>(this);
    	}
    	
    	public IEntitySet<Hqub.Esenin.App.Model.IPoem> Poems
    	{
    		get; private set;
    	}
    	
    	public IEntitySet<Hqub.Esenin.App.Model.IQuatrain> Quatrains
    	{
    		get; private set;
    	}
    	
        public IEntitySet<T> EntitySet<T>() where T : class {
            var itemType = typeof(T);
            if (typeof(T).Equals(typeof(Hqub.Esenin.App.Model.IPoem))) {
                return (IEntitySet<T>)this.Poems;
            }
            if (typeof(T).Equals(typeof(Hqub.Esenin.App.Model.IQuatrain))) {
                return (IEntitySet<T>)this.Quatrains;
            }
            throw new InvalidOperationException(typeof(T).FullName + " is not a recognized entity interface type.");
        }
    
        } // end class MyEntityContext
        
}
namespace Hqub.Esenin.App.Model 
{
    
    public partial class Poem : BrightstarEntityObject, IPoem 
    {
    	public Poem(BrightstarEntityContext context, BrightstarDB.Client.IDataObject dataObject) : base(context, dataObject) { }
        public Poem(BrightstarEntityContext context) : base(context, typeof(Poem)) { }
    	public Poem() : base() { }
    	public System.String Id { get {return GetKey(); } set { SetKey(value); } }
    	#region Implementation of Hqub.Esenin.App.Model.IPoem
    
    	public System.String Title
    	{
            		get { return GetRelatedProperty<System.String>("Title"); }
            		set { SetRelatedProperty("Title", value); }
    	}
    
    	public System.Int32 Year
    	{
            		get { return GetRelatedProperty<System.Int32>("Year"); }
            		set { SetRelatedProperty("Year", value); }
    	}
    
    	public System.Boolean Compleated
    	{
            		get { return GetRelatedProperty<System.Boolean>("Compleated"); }
            		set { SetRelatedProperty("Compleated", value); }
    	}
    
    	public System.Boolean Bookmarked
    	{
            		get { return GetRelatedProperty<System.Boolean>("Bookmarked"); }
            		set { SetRelatedProperty("Bookmarked", value); }
    	}
    	public System.Collections.Generic.ICollection<Hqub.Esenin.App.Model.IQuatrain> Quatrains
    	{
    		get { return GetRelatedObjects<Hqub.Esenin.App.Model.IQuatrain>("Quatrains"); }
    		set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("Quatrains", value); }
    								}
    	#endregion
    }
}
namespace Hqub.Esenin.App.Model 
{
    
    public partial class Quatrain : BrightstarEntityObject, IQuatrain 
    {
    	public Quatrain(BrightstarEntityContext context, BrightstarDB.Client.IDataObject dataObject) : base(context, dataObject) { }
        public Quatrain(BrightstarEntityContext context) : base(context, typeof(Quatrain)) { }
    	public Quatrain() : base() { }
    	public System.String Id { get {return GetKey(); } set { SetKey(value); } }
    	#region Implementation of Hqub.Esenin.App.Model.IQuatrain
    
    	public System.String Text
    	{
            		get { return GetRelatedProperty<System.String>("Text"); }
            		set { SetRelatedProperty("Text", value); }
    	}
    
    	public System.Int32 Order
    	{
            		get { return GetRelatedProperty<System.Int32>("Order"); }
            		set { SetRelatedProperty("Order", value); }
    	}
    
    	public System.Boolean Compleated
    	{
            		get { return GetRelatedProperty<System.Boolean>("Compleated"); }
            		set { SetRelatedProperty("Compleated", value); }
    	}
    
    	public System.Boolean Selected
    	{
            		get { return GetRelatedProperty<System.Boolean>("Selected"); }
            		set { SetRelatedProperty("Selected", value); }
    	}
    
    	public Hqub.Esenin.App.Model.IPoem ParentPoem
    	{
            get { return GetRelatedObject<Hqub.Esenin.App.Model.IPoem>("ParentPoem"); }
            set { SetRelatedObject<Hqub.Esenin.App.Model.IPoem>("ParentPoem", value); }
    	}
    	#endregion
    }
}