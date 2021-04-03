# SOS-App-LHDShare2021
SOS App that SMSes pre-decided phone number with the coordinates and address of the device

### Description

**FakeACall** is an Android app that allows the user to send an SOS message to a predecided phone number.

###  Components

* The [```main```](https://github.com/adityaoberai/SOS-App-LHDShare2021/tree/main) branch contains the **Xamarin.Forms** project used to build the Android app that gets the coordinates of the phone through the **Xamarin.Essentials Geolocation API** and call the SOS **Azure Function**.  

* The [```twilio_function```](https://github.com/adityaoberai/SOS-App-LHDShare2021/tree/sos_function) branch contains the **Azure Function** that reverse geocodes the coordinates to get the address from the **Google Maps Geocoding API** and uses **Twilio Programmable Message** to send an SOS message to predecided number.  

---
