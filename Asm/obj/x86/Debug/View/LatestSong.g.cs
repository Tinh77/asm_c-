﻿#pragma checksum "C:\Users\Tinh\source\repos\Asm\Asm\View\LatestSong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "718BDE4986ACDFA5FC5E8A9F13F80E23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asm.View
{
    partial class LatestSong : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Automation_AutomationProperties_Name(global::Windows.UI.Xaml.DependencyObject obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                global::Windows.UI.Xaml.Automation.AutomationProperties.SetName(obj, value);
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Media_ImageBrush_ImageSource(global::Windows.UI.Xaml.Media.ImageBrush obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.ImageSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class LatestSong_obj13_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ILatestSong_Bindings
        {
            private global::Asm.Entity.Song dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj13;
            private global::Windows.UI.Xaml.Controls.TextBlock obj14;
            private global::Windows.UI.Xaml.Controls.TextBlock obj15;
            private global::Windows.UI.Xaml.Media.ImageBrush obj16;

            public LatestSong_obj13_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 13: // View\LatestSong.xaml line 24
                        this.obj13 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 14: // View\LatestSong.xaml line 31
                        this.obj14 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 15: // View\LatestSong.xaml line 35
                        this.obj15 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 16: // View\LatestSong.xaml line 27
                        this.obj16 = (global::Windows.UI.Xaml.Media.ImageBrush)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj13.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::Asm.Entity.Song) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // ILatestSong_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Asm.Entity.Song)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Asm.Entity.Song obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_name(obj.name, phase);
                        this.Update_singer(obj.singer, phase);
                        this.Update_thumbnail(obj.thumbnail, phase);
                    }
                }
            }
            private void Update_name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // View\LatestSong.xaml line 24
                    if ((this.obj13.Target as global::Windows.UI.Xaml.Controls.StackPanel) != null)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Automation_AutomationProperties_Name((this.obj13.Target as global::Windows.UI.Xaml.Controls.StackPanel), obj, null);
                    }
                    // View\LatestSong.xaml line 31
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj14, obj, null);
                }
            }
            private void Update_singer(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // View\LatestSong.xaml line 35
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj15, obj, null);
                }
            }
            private void Update_thumbnail(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // View\LatestSong.xaml line 27
                    XamlBindingSetters.Set_Windows_UI_Xaml_Media_ImageBrush_ImageSource(this.obj16, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class LatestSong_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ILatestSong_Bindings
        {
            private global::Asm.View.LatestSong dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj12;

            private LatestSong_obj1_BindingsTracking bindingsTracking;

            public LatestSong_obj1_Bindings()
            {
                this.bindingsTracking = new LatestSong_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 12: // View\LatestSong.xaml line 21
                        this.obj12 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        this.bindingsTracking.RegisterTwoWayListener_12(this.obj12);
                        break;
                    default:
                        break;
                }
            }

            // ILatestSong_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Asm.View.LatestSong)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Asm.View.LatestSong obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ArrayLatestSong(obj.ArrayLatestSong, phase);
                    }
                }
            }
            private void Update_ArrayLatestSong(global::System.Collections.ObjectModel.ObservableCollection<global::Asm.Entity.Song> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ArrayLatestSong(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\LatestSong.xaml line 21
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj12, obj, null);
                }
            }
            private void UpdateTwoWay_12_ItemsSource()
            {
                if (this.initialized)
                {
                    this.dataRoot.ArrayLatestSong = (global::System.Collections.ObjectModel.ObservableCollection<global::Asm.Entity.Song>)this.obj12.ItemsSource;
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class LatestSong_obj1_BindingsTracking
            {
                private global::System.WeakReference<LatestSong_obj1_Bindings> weakRefToBindingObj; 

                public LatestSong_obj1_BindingsTracking(LatestSong_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<LatestSong_obj1_Bindings>(obj);
                }

                public LatestSong_obj1_Bindings TryGetBindingObject()
                {
                    LatestSong_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ArrayLatestSong(null);
                }

                public void PropertyChanged_ArrayLatestSong(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    LatestSong_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::Asm.Entity.Song> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Asm.Entity.Song>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_ArrayLatestSong(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    LatestSong_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::Asm.Entity.Song> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Asm.Entity.Song>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::Asm.Entity.Song> cache_ArrayLatestSong = null;
                public void UpdateChildListeners_ArrayLatestSong(global::System.Collections.ObjectModel.ObservableCollection<global::Asm.Entity.Song> obj)
                {
                    if (obj != cache_ArrayLatestSong)
                    {
                        if (cache_ArrayLatestSong != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ArrayLatestSong).PropertyChanged -= PropertyChanged_ArrayLatestSong;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_ArrayLatestSong).CollectionChanged -= CollectionChanged_ArrayLatestSong;
                            cache_ArrayLatestSong = null;
                        }
                        if (obj != null)
                        {
                            cache_ArrayLatestSong = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ArrayLatestSong;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_ArrayLatestSong;
                        }
                    }
                }
                public void RegisterTwoWayListener_12(global::Windows.UI.Xaml.Controls.ListView sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.ItemsControl.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_12_ItemsSource();
                        }
                    });
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\LatestSong.xaml line 72
                {
                    this.MediaPlayer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 3: // View\LatestSong.xaml line 55
                {
                    this.MinDuration = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // View\LatestSong.xaml line 56
                {
                    this.Progress = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 5: // View\LatestSong.xaml line 57
                {
                    this.MaxDuration = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // View\LatestSong.xaml line 59
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element6 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element6).Click += this.PlayBack;
                }
                break;
            case 7: // View\LatestSong.xaml line 60
                {
                    this.PlayButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.PlayButton).Click += this.PlayClick;
                }
                break;
            case 8: // View\LatestSong.xaml line 61
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element8 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element8).Click += this.PlayNext;
                }
                break;
            case 9: // View\LatestSong.xaml line 63
                {
                    this.VolumeSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.VolumeSlider).ValueChanged += this.VolumeSlider_ValueChanged;
                }
                break;
            case 10: // View\LatestSong.xaml line 64
                {
                    this.volume = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // View\LatestSong.xaml line 50
                {
                    this.NowPlaying = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // View\LatestSong.xaml line 21
                {
                    this.MenuList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 13: // View\LatestSong.xaml line 24
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element13 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element13).Tapped += this.StackPanel_Tapped;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // View\LatestSong.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    LatestSong_obj1_Bindings bindings = new LatestSong_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 13: // View\LatestSong.xaml line 24
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element13 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    LatestSong_obj13_Bindings bindings = new LatestSong_obj13_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element13.DataContext);
                    element13.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element13, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element13, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

