# LoklakDotNet

This is the .NET API wrapper for the Loklak server (http://loklak.org).

##Installation
To install LoklakDotNet, run the following command in the Package Manager Console.

`Install-Package LoklakDotNet`

You can also search for `loklak` in the Nuget Package Manager.

##How to use
See the LoklakDotNetTests project for usage examples. async/await pattern is followed. All methods output the raw JSON string response. Parse the JSON using a JSON parser of your choice. Examples in LoklakDotNetTests use Newtonsoft.JSON.
For documentation on the API, go [here](http://loklak.org/api.html).

###Initialize

`Loklak loklak = new Loklak();` or `Loklak loklak = new Loklak("http://myloklakapp/api");`

###Status

`var result = await loklak.status();`

###Search
```
var st = new LoklakSearchTerm(); //See LoklakSearchTerm properties for more options
st.terms = "loklak";
var result = await loklak.search(st);
```
Full method signature:

`search(LoklakSearchTerm q, int count = 100, string source="cache", IList<string> fields = null, int limit=-1, int timeZoneOffset=-1)`

###Hello

`var result = await loklak.hello();`

###Peers

`var result = await loklak.peers();`

###Geocode

```
var places = new List<string>();
places.Add("Delhi");
places.Add("Berlin");
var result = await loklak.geocode(places);
```

###User

`var result = await loklak.user("loklak_app", <max-follower-count>, <max-following-count>);`

