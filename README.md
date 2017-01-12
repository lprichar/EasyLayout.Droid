# EasyLayout.Droid
EasyLayout.Droid makes it easier to read, write, and maintain relative layouts in Xamarin Android. It's a port of Frank Krueger's EasyLayout (https://gist.github.com/praeclarum/6225853).

## Sample Project

The best place to get started is to take a look at the [sample project](https://github.com/lprichar/EasyLayout.Droid/blob/master/EasyLayout.Droid.Sample/MainActivity.cs).

![Sample Project Screenshot](/SampleProject.png)

## Example 1 - Parent Align


If you want to align an image to the edges of the frame you used to do this:

````
var layoutParams = new RelativeLayout.LayoutParams(
    ViewGroup.LayoutParams.MatchParent,
    ViewGroup.LayoutParams.MatchParent);
layoutParams.AddRule(LayoutRules.AlignParentTop);
layoutParams.AddRule(LayoutRules.AlignParentBottom);
layoutParams.AddRule(LayoutRules.AlignParentRight);
layoutParams.AddRule(LayoutRules.AlignParentLeft);
_image.LayoutParams = layoutParams;
````

Now you can do this:

````
relativeLayout.ConstrainLayout(() =>
    _image.Top == relativeLayout.Top
    && _image.Right == relativeLayout.Right
    && _image.Left == relativeLayout.Left
    && _image.Bottom == relativeLayout.Bottom
    );
````

There's no need to set LayoutParams at all.  If they don't exist EasyLayout.Droid will add them, if they do EasyLayout.Droid will append to them.  And if you don't add them it will take care of choosing LayoutParams.MatchParent or WrapContent, EasyLayout.Droid.

## Example 2 - Relative Alignment and Constants

If you wanted to align an image 20 dp under another image and center align it to the parent you used to do this:

````
var layoutParams = new RelativeLayout.LayoutParams(
    ViewGroup.LayoutParams.WrapContent,
    ViewGroup.LayoutParams.WrapContent);
layoutParams.AddRule(LayoutRules.CenterHorizontal);
layoutParams.AddRule(LayoutRules.AlignBottom, image1.Id);
layoutParams.TopMargin = DpToPx(20);
_image2.LayoutParams = layoutParams;
````

There's a couple of gotchas.  

1. If you set the TopMargin to 20, then Android assumes you mean pixels not device independent pixels.  To fix that you need to remember to call a function like DpToPx().  
1. Your relative view (image1) needs to have an Id.  If you forget to set it there's no error, it just does strange layout things.

EasyLayout.Droid replaces the code above with:

````
relativeLayout.ConstrainLayout(() =>
    _image2.Top == _image1.Bottom + 20
    && _image2.GetCenterX() == relativeLayout.GetCenterX()
    );
````

That's less code and easier to read plus there's some other small benefits.  

* If you forget to add an Id to _image1, EasyLayout.Droid will automatically add one for you.  
* EasyLayout.Droid always assumes every number is in Dp, so it automatically converts all literals for you.

Incidentally, GetCenterX() is one of a couple of new extension methods along with GetCenterY() and GetCenter().

## Example 3 - Constants


Constants weren't difficult to work with previously, but for completeness they used to work like this:

````
var layoutParams = new RelativeLayout.LayoutParams(
    DpToPx(50),
    DpToPx(ViewModel.SomeHeight);
_image2.LayoutParams = layoutParams;
````

With EasyLayout.Droid you can do this:

````
relativeLayout.ConstrainLayout(() =>
    _image.Width == 50
    && _image.Height == ViewModel.SomeHeight.ToConst()
    );
````

As mentioned previously 50 will be assumed to be in dp and will be auto-converted to pixels.  Also arbitrary properties such as SomeHeight will need the .ToConst() extension method applied in order to tell EasyLayout.Droid that they should be treated as constants.

## Installation

If you want to add this to your project you can either [install via NuGet](https://www.nuget.org/packages/EasyLayout.Droid/) (safer):

`Install-Package EasyLayout.Droid`

or if you think it's perfect as is (you don't want updates) you can copy [EasyLayoutDroid.cs](https://github.com/lprichar/EasyLayout.Droid/blob/master/EasyLayout.Droid/EasyLayout.cs) into your source.

## More

For more information read [Introducing EasyLayout.Droid](http://www.leerichardson.com/2017/01/introducing-easylayoutdroid-for-simpler.html).

## License

All code is MIT Licensed.
