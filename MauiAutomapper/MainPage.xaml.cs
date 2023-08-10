using AutoMapper;

namespace MauiAutomapper;

public partial class MainPage : ContentPage
{
    private IMapper _mapper;

    public MainPage()
    {
        InitializeComponent();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<MyClass, MyClassDto>().ReverseMap());
        _mapper = config.CreateMapper();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        var myClass = new MyClass()
        {
            Values = new List<int> { 1, 2, 3 }
        };
        // Works on Android, fails on iOS
        var myClassDto = _mapper.Map<MyClassDto>(myClass);
        System.Diagnostics.Debug.WriteLine(myClassDto);
    }
}


