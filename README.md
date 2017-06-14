# Xamarin QRCodeReaderView Android Binding Library

#### Modification of ZXING Barcode Scanner project for easy Android QR-Code detection and AR purposes. ####

This project implements an Android view which show camera and notify when there's a QR code inside the preview.

Some Classes of camera controls and autofocus are taken and slightly modified from Barcode Scanner Android App.

You can also use this for Augmented Reality purposes, as you get QR control points coordinates when decoding.

Usage
-----

- Add a "QRCodeReaderView" in the layout editor like you actually do with a button for example.
- In your onCreate method, you can find the view as usual, using `FindViewById()` function.
- Create an Activity which implements `OnQRCodeReadListener`, and let implements required methods or set a `OnQRCodeReadListener` to the QRCodeReaderView object
- Make sure you have camera permissions in order to use the library. (https://developer.android.com/training/permissions/requesting.html)

```xml

 <com.dlazaro66.qrcodereaderview.QRCodeReaderView
        android:id="@+id/qrdecoderview"
        android:layout_width="match_parent"
        android:layout_height="match_parent" />

```

- Start & Stop camera preview in OnPause() and OnResume() overriden methods.
- You can place widgets or views over QRDecoderView.
 
```c#
public class DecoderActivity : Activity, IOnQRCodeReadListener {

    private TextView resultTextView;
	private QRCodeReaderView qrCodeReaderView;

    protected override void OnCreate(Bundle savedInstanceState) {
        super.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_decoder);
        
        qrCodeReaderView = (QRCodeReaderView) FindViewById(Resource.Id.qrdecoderview);
        qrCodeReaderView.SetOnQRCodeReadListener(this);

    	  // Use this function to enable/disable decoding
        qrCodeReaderView.QRDecodingEnabled = (true);

        // Use this function to change the autofocus interval (default is 5 secs)
        qrCodeReaderView.AutofocusInterval = (2000L);

        // Use this function to enable/disable Torch
        qrCodeReaderView.TorchEnabled = (true);

        // Use this function to set front camera preview
        qrCodeReaderView.SetFrontCamera();

        // Use this function to set back camera preview
        qrCodeReaderView.SetBackCamera();
    }

    // Called when a QR is decoded
    // "text" : the text encoded in QR
    // "points" : points where QR control points are placed in View
	public void OnQRCodeRead(String text, Point[] points) {
		resultTextView.Text = (text);
	}
    
	protected override void OnResume() {
		super.OnResume();
		qrCodeReaderView.StartCamera();
	}
	
	protected override void OnPause() {
		super.OnPause();
		qrCodeReaderView.StopCamera();
	}
}
```

Add it to your project
----------------------

Add QRCodeReaderView dependency to your build.gradle

```
Install-Package Naxam.QRCodeReaderView.Droid
```

MIT License

Copyright (c) 2017 NAXAM

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

[1]: https://github.com/zxing/zxing/
[2]: https://www.Swapcard.com/
[3]: https://raw.githubusercontent.com/dlazaro66/QRCodeReaderView