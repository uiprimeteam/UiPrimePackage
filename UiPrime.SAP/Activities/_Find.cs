using System;
using System.Activities;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UiPrime.SAPCore;
using sapfewse;

// Authors: Thiago Minhaqui Oechsler / Robson Fernando da Veiga
// UiPrime Hackathon Team 
// Created on 12th August 2018
// This code is free. Check LICENSE.txt for MIT Open Source License terms.
namespace UiPrime.SAP.Visual_Objects.Find
{
    [Description("Searches by id through a SAP session for a Gui control visual object.\nIf the id property is a fully qualified id, the activity will first check if the\ncontainer object's id is a prefix of the given property.\nIf that is the case then this prefix is truncated.")]
    public sealed class FindById<T> :  CodeActivity<T>
	{
        [Category("Input")]
        [Description("GuiSession: The SAP session to search for the visual component.")]
        public InArgument<GuiSession> Session { get; set; }

        [RequiredArgument]
        [Category("Input")]
        [Description("string: The SAP unique id for the desired component.\nIf this is a fully qualified id, the activity will first check if the\ncontainer object's id is a prefix of the given property.\nIf that is the case then this prefix is truncated.")]
        public InArgument<String> Id { get; set; }

        protected override T Execute(CodeActivityContext context)
        {		
			T temp = default(T);
            GuiSession currentSession = this.Session.Get(context);
			if(currentSession==null){
				currentSession = SAPGui.GetCurrentSession();
			}
			
			object output = (currentSession as GuiSession).FindById(this.Id.Get(context), false);
			
			if(output == null){
				return temp;
			}else{
				return (T)(currentSession as GuiSession).FindById(this.Id.Get(context), false);
			}
        }
    }

    [Description("Searches by name through a SAP session for a Gui control visual object.\nThis activity does not guarantee a unique result, it will simply return the first\ndescendant matching the name.")]
    public sealed class FindByName<SourceType,TargetType> :  CodeActivity<TargetType>
	{	
		[Category("Input")]
        [Description("Source element to search for descendants with the given name.")]
        public InArgument<SourceType> Source { get; set; }

        [RequiredArgument]
        [Category("Input")]
        [Description("string: Internal name of the component to search")]
        public InArgument<String> Name { get; set; }

        protected override TargetType Execute(CodeActivityContext context)
        {		
			object[] args = {this.Name.Get(context),typeof(TargetType).Name};
			try{
				return (TargetType)typeof(SourceType).InvokeMember("FindByName", BindingFlags.InvokeMethod, null,this.Source.Get(context),args);
			}catch(Exception e){
				return default(TargetType);
			}
        }
    }

    [Description("Searches by name through a SAP session for all possible Gui control visual object.\nThis activity returns a list of all possible descendants matching the name.")]
    public sealed class FindAllByName<SourceType,TargetType> :  CodeActivity<List<TargetType>>
	{	
		[Category("Input")]
        [Description("Source element to search for descendants with the given name.")]
        public InArgument<SourceType> Source { get; set; }

        [RequiredArgument]
        [Category("Input")]
        [Description("string: Internal name of the components to search")]
        public InArgument<String> Name { get; set; }

        protected override List<TargetType> Execute(CodeActivityContext context)
        {		
			object[] args = {this.Name.Get(context),typeof(TargetType).Name};
			try{
				return SAPGui.FindAllByNameCustom<SourceType,TargetType>(this.Source.Get(context),this.Name.Get(context));
			}catch(Exception e){
				return default(List<TargetType>);
			}
        }
    }
}