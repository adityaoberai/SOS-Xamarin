# SOS-App-LHDShare2021
SOS App that SMSes pre-decided phone number with the coordinates and address of the device

![Banner](https://oberai.dev/Assets/img/Projects/SOS%20App.png)

### Description

**SOS App** is an Android app that allows the user to send an SOS message to a predecided phone number.

This SOS App was built as a part of the **Use GPS or Maps Technology** session at **MLH Local Hack Day: Share 2021**.

###  Components

* The [```main```](https://github.com/adityaoberai/SOS-App-LHDShare2021/tree/main) branch contains the **Xamarin.Forms** project used to build the Android app that gets the coordinates of the phone through the **Xamarin.Essentials Geolocation API** and call the SOS **Azure Function**.  

* The [```sos_function```](https://github.com/adityaoberai/SOS-App-LHDShare2021/tree/sos_function) branch contains the **Azure Function** that reverse geocodes the coordinates to get the address from the **Google Maps Geocoding API** and uses **Twilio Programmable Message** to send an SOS message to predecided number.  

![SOS App Pages](https://user-images.githubusercontent.com/31401437/179421060-532712c2-5770-4b4a-b437-0ed0481f8aac.png)

---

### Learn How To Build It

Learn how to build the solution via the [YouTube Stream Here](https://www.youtube.com/watch?v=Oomp0L4yeFA)
