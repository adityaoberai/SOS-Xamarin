# SOS-App-LHDShare2021
SOS App that SMSes pre-decided phone number with the coordinates and address of the device

### Description

**SOS App** is an Android app that allows the user to send an SOS message to a predecided phone number.

This SOS App was built as a part of the **Use GPS or Maps Technology** session at **MLH Local Hack Day: Share 2021**.

###  Components

* The [```main```](https://github.com/adityaoberai/SOS-App-LHDShare2021/tree/main) branch contains the **Xamarin.Forms** project used to build the Android app that gets the coordinates of the phone through the **Xamarin.Essentials Geolocation API** and call the SOS **Azure Function**.  

* The [```sos_function```](https://github.com/adityaoberai/SOS-App-LHDShare2021/tree/sos_function) branch contains the **Azure Function** that reverse geocodes the coordinates to get the address from the **Google Maps Geocoding API** and uses **Twilio Programmable Message** to send an SOS message to predecided number.  

---
