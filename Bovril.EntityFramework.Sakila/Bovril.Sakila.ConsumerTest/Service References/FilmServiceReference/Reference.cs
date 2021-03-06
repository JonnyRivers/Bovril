﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bovril.Sakila.ConsumerTest.FilmServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Film", Namespace="http://schemas.datacontract.org/2004/07/Bovril.Sakila.ServiceApp")]
    [System.SerializableAttribute()]
    public partial class Film : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FilmIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FilmId {
            get {
                return this.FilmIdField;
            }
            set {
                if ((this.FilmIdField.Equals(value) != true)) {
                    this.FilmIdField = value;
                    this.RaisePropertyChanged("FilmId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FilmServiceReference.IFilmService")]
    public interface IFilmService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/GetNumFilms", ReplyAction="http://tempuri.org/IFilmService/GetNumFilmsResponse")]
        int GetNumFilms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/GetNumFilms", ReplyAction="http://tempuri.org/IFilmService/GetNumFilmsResponse")]
        System.Threading.Tasks.Task<int> GetNumFilmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/GetAllFilms", ReplyAction="http://tempuri.org/IFilmService/GetAllFilmsResponse")]
        Bovril.Sakila.ConsumerTest.FilmServiceReference.Film[] GetAllFilms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/GetAllFilms", ReplyAction="http://tempuri.org/IFilmService/GetAllFilmsResponse")]
        System.Threading.Tasks.Task<Bovril.Sakila.ConsumerTest.FilmServiceReference.Film[]> GetAllFilmsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFilmServiceChannel : Bovril.Sakila.ConsumerTest.FilmServiceReference.IFilmService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FilmServiceClient : System.ServiceModel.ClientBase<Bovril.Sakila.ConsumerTest.FilmServiceReference.IFilmService>, Bovril.Sakila.ConsumerTest.FilmServiceReference.IFilmService {
        
        public FilmServiceClient() {
        }
        
        public FilmServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FilmServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilmServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilmServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetNumFilms() {
            return base.Channel.GetNumFilms();
        }
        
        public System.Threading.Tasks.Task<int> GetNumFilmsAsync() {
            return base.Channel.GetNumFilmsAsync();
        }
        
        public Bovril.Sakila.ConsumerTest.FilmServiceReference.Film[] GetAllFilms() {
            return base.Channel.GetAllFilms();
        }
        
        public System.Threading.Tasks.Task<Bovril.Sakila.ConsumerTest.FilmServiceReference.Film[]> GetAllFilmsAsync() {
            return base.Channel.GetAllFilmsAsync();
        }
    }
}
