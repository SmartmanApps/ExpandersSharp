using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

namespace ExpandersSharp;

public class NewSharpPage : ContentPage
{
    NewSharpPageViewModel newSharpPageViewModel;
    public NewSharpPage()
    {
        BindingContext = newSharpPageViewModel = new NewSharpPageViewModel();

        Grid MainGrid = new Grid
        {
            RowDefinitions =
            {
// DOESN'T (VISIBLY) EXPAND ON WINDOWS WITH 1ST ROW SET TO GRIDLENGTH.AUTO
//                new RowDefinition{Height = GridLength.Auto},
// (VISIBLY) EXPANDS ON WINDOWS WITH 1ST ROW SET TO GRIDLIENGTH.STAR
                new RowDefinition(GridLength.Star),
                new RowDefinition{Height = GridLength.Auto},
                new RowDefinition(GridLength.Star),
            },
        };

        MainGrid.Children.Add(new SimpleStaticExpander().Row(0));


        MainGrid.Children.Add(new myLabel().Row(1));


        MainGrid.Children.Add(new myVerticalStackLayout().Bind(BindableLayout.ItemsSourceProperty, nameof(newSharpPageViewModel.MyPropertyItems))
            .ItemTemplate(new DataTemplate(() =>
            {
                return new SimpleDynamicExpander();
                
            })).Row(2));

        Content = new Grid
        {
            Children = {

                MainGrid
            }
        };
    }

    class SimpleStaticExpander : Expander
    {
        public SimpleStaticExpander()
        {
            
            Header = new Grid
            {
                ColumnSpacing = 10,
                BackgroundColor = Colors.LightGray,
                Padding = new Thickness(10),
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
                },


           Children =
           {
                    new Label
                    {
                        Text = "Simple Expander (Tap Me)",
                        FontSize = 16,
                        FontAttributes = FontAttributes.Bold,
                        VerticalTextAlignment = TextAlignment.Center
                    }.Column(0),


           new Image
            {
                
                HeightRequest = 30,
                WidthRequest = 30,
                Source = "arrdwn.png",
                Triggers =
                {
                    new DataTrigger(typeof(Image))
                    {
                        Binding = new Binding
                        {
                            Source = this,
                            Path = "IsExpanded"
                        },
                        Value = true,
                        Setters =
                        {
                            new Setter
                            {
                                Property = Image.RotationProperty,
                                Value = 180
                            }
                        }
                    },
                    new DataTrigger(typeof(Image))
                    {
                        Binding = new Binding
                        {
                            Source = this,
                            Path = "IsExpanded"
                        },
                        Value = false,
                        Setters =
                        {
                            new Setter
                            {
                                Property = Image.RotationProperty,
                                Value = 0
                            }
                        }
                    }
                }
                }.Column(1)
             }
            };


            Content = new StackLayout
            {
                Padding = new Thickness(10),
                Children =
                {
                    new Label { Text = "Item 1" },
                    new Label { Text = "Item 2" }
                }
            };
         }
    }






    class myLabel : Label
    {
        public myLabel()
        {
            Text = "Dynamic Expander Example below";
            TextColor = Colors.Black;
            HorizontalTextAlignment = TextAlignment.Center;
        }
    }


    class myVerticalStackLayout : VerticalStackLayout
    {
       public myVerticalStackLayout()
       {
            
                

       }
    }

    class SimpleDynamicExpander : Expander
    {

        public SimpleDynamicExpander()
        {
            VerticalOptions = LayoutOptions.StartAndExpand;

            var headerLabel = new Label().Column(0).TextColor(Colors.Black);
            headerLabel.SetBinding(Label.TextProperty, "Header");

            Header = new Grid
            {
                ColumnSpacing = 10,
                BackgroundColor = Colors.LightGray,
                Padding = new Thickness(10),
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
                },

              
           Children =
           {
             headerLabel,
              new Image
            {

                HeightRequest = 30,
                WidthRequest = 30,
                Source = "arrdwn.png",
                Triggers =
                {
                    new DataTrigger(typeof(Image))
                    {
                        Binding = new Binding
                        {
                            Source = this,
                            Path = "IsExpanded"
                        },
                        Value = true,
                        Setters =
                        {
                            new Setter
                            {
                                Property = Image.RotationProperty,
                                Value = 180
                            }
                        }
                    },
                    new DataTrigger(typeof(Image))
                    {
                        Binding = new Binding
                        {
                            Source = this,
                            Path = "IsExpanded"
                        },
                        Value = false,
                        Setters =
                        {
                            new Setter
                            {
                                Property = Image.RotationProperty,
                                Value = 0
                            }
                        }
                    }
                }
                }.Column(1)
             }
            };
            Content = new StackLayout
            {
                
            }.Bind(BindableLayout.ItemsSourceProperty, nameof(newSharpPageViewModel.MyPropertyItems))
            .ItemTemplate(new DataTemplate(() =>
            {
                var reserveLabel = new Label
                {
                    FontSize = 18,
                    TextColor = Colors.Black
                };

                reserveLabel.SetBinding(Label.TextProperty, new Binding("Reserve"));

                var addressLabel = new Label();

                addressLabel.SetBinding(Label.TextProperty, new Binding("Address"));

                return new StackLayout
                {
                    Margin = new Thickness(5),
                    Children = { reserveLabel, addressLabel }
                };

            }));
           
        }
  }
}
