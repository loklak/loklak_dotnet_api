# LoklakDotNet

[![Build Status](https://travis-ci.org/loklak/loklak_dotnet_wrapper.svg?branch=master)](https://travis-ci.org/loklak/loklak_dotnet_wrapper)

This is the .NET API wrapper for the Loklak server (http://loklak.org).

##Installation
To install LoklakDotNet, run the following command in the Package Manager Console.

`Install-Package LoklakDotNet`

You can also search for `loklak` in the Nuget Package Manager.

###Supported Platforms


1. .NET Framework 4.5
2. ASP.NET Core 5.0
3. Windows 8/8.1
4. Windows Universal (UWP)
5. Windows Phone 8.1
6. Windows Phone Silverlight 8.1
7. Xamarin.Android
8. Xamarin.iOS
9. Xamarin.iOS (Classic)

##How to use
See the LoklakDotNetTests project for usage examples. async/await pattern is followed. All methods output the raw JSON string response. Parse the JSON using a JSON parser of your choice. Examples in LoklakDotNetTests use Newtonsoft.JSON.
For documentation on the API, go [here](http://loklak.org/api.html).

<a name='contents'></a>
# Contents 

- [Loklak](#T-LoklakDotNet-Loklak 'LoklakDotNet.Loklak')
  - [#ctor(apiUrl)](#M-LoklakDotNet-Loklak-#ctor-System-String- 'LoklakDotNet.Loklak.#ctor(System.String)')
  - [geocode(places)](#M-LoklakDotNet-Loklak-geocode-System-Collections-Generic-IList{System-String}- 'LoklakDotNet.Loklak.geocode(System.Collections.Generic.IList{System.String})')
  - [hello()](#M-LoklakDotNet-Loklak-hello 'LoklakDotNet.Loklak.hello')
  - [markdown(text,color_text,color_background,padding,uppercase)](#M-LoklakDotNet-Loklak-markdown-System-String,System-String,System-String,System-Int32,System-Boolean- 'LoklakDotNet.Loklak.markdown(System.String,System.String,System.String,System.Int32,System.Boolean)')
  - [peers()](#M-LoklakDotNet-Loklak-peers 'LoklakDotNet.Loklak.peers')
  - [search(q,count,source,fields,limit,timeZoneOffset)](#M-LoklakDotNet-Loklak-search-LoklakDotNet-LoklakSearchTerm,System-Int32,System-String,System-Collections-Generic-IList{System-String},System-Int32,System-Int32- 'LoklakDotNet.Loklak.search(LoklakDotNet.LoklakSearchTerm,System.Int32,System.String,System.Collections.Generic.IList{System.String},System.Int32,System.Int32)')
  - [status()](#M-LoklakDotNet-Loklak-status 'LoklakDotNet.Loklak.status')
  - [user(screen_name,follower_count,following_count)](#M-LoklakDotNet-Loklak-user-System-String,System-Int32,System-Int32- 'LoklakDotNet.Loklak.user(System.String,System.Int32,System.Int32)')
- [LoklakSearchTerm](#T-LoklakDotNet-LoklakSearchTerm 'LoklakDotNet.LoklakSearchTerm')

<a name='T-LoklakDotNet-Loklak'></a>
## Loklak 

##### Namespace

LoklakDotNet

<a name='M-LoklakDotNet-Loklak-#ctor-System-String-'></a>
### #ctor(apiUrl) `constructor` 

##### Summary

Initializes the Loklak API wrapper

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiUrl | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Optional API Url |

`Loklak loklak = new Loklak();` or `Loklak loklak = new Loklak("http://myloklakapp/api/");`


<a name='M-LoklakDotNet-Loklak-geocode-System-Collections-Generic-IList{System-String}-'></a>
### geocode(places) `method` 

##### Summary

This servlet provides geocoding of place names to location coordinates and also reverse geocoding of location coordinates to place names.

##### Returns

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| places | [System.Collections.Generic.IList{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{System.String}') | List of place names |

```
var places = new List<string>();
places.Add("Delhi");
places.Add("Berlin");
var result = await loklak.geocode(places);
```

<a name='M-LoklakDotNet-Loklak-hello'></a>
### hello() `method` 

##### Summary

The hello servlet is part of the loklak peer-to-peer bootstrap process and shall be used to announce that a new client has been started up. The hello request is done automatically after a loklak startup against the loklak backend as configured in the settings in field backend. The back-end server then does not return any data, just an 'ok' string object.

##### Returns

{"status":"ok"}

##### Parameters

This method has no parameters.

`var result = await loklak.hello();`

<a name='M-LoklakDotNet-Loklak-markdown-System-String,System-String,System-String,System-Int32,System-Boolean-'></a>
### markdown(text,color_text,color_background,padding,uppercase) `method` 

##### Summary

This servlet provides an image with text on it.

##### Returns

Image object in string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | text to be printed, markdown possible |
| color_text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | text color |
| color_background | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | background color |
| padding | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | space around text |
| uppercase | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

`var result = await loklak.markdown("hello");`


<a name='M-LoklakDotNet-Loklak-peers'></a>
### peers() `method` 

##### Summary

This servlet combined the result of the hello calls from all peers and provides a list of addresses where the remote peers can be accessed.

##### Returns



##### Parameters

This method has no parameters.

`var result = await loklak.peers();`

<a name='M-LoklakDotNet-Loklak-search-LoklakDotNet-LoklakSearchTerm,System-Int32,System-String,System-Collections-Generic-IList{System-String},System-Int32,System-Int32-'></a>
### search(q,count,source,fields,limit,timeZoneOffset) `method` 

##### Summary

Get a search result from the server

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| q | [LoklakDotNet.LoklakSearchTerm](#T-LoklakDotNet-LoklakSearchTerm 'LoklakDotNet.LoklakSearchTerm') | query term |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | the wanted number of results |
| source | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | the source for the search cache|backend|twitter|all |
| fields | [System.Collections.Generic.IList{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{System.String}') | aggregation fields for search facets |
| limit | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | a limitation of number of facets for each aggregation |
| timeZoneOffset | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | offset applied on since:, until: and the date histogram |

```
var st = new LoklakSearchTerm(); //See LoklakSearchTerm properties for more options
st.terms = "loklak";
var result = await loklak.search(st);
```

<a name='M-LoklakDotNet-Loklak-status'></a>
### status() `method` 

##### Summary

The status servlet shows the size of the internal Elasticsearch search index for messages and users. Furthermore, the servlet reflects the current browser clients settings in the client_info.

##### Returns



##### Parameters

This method has no parameters.

`var result = await loklak.status();`

<a name='M-LoklakDotNet-Loklak-user-System-String,System-Int32,System-Int32-'></a>
### user(screen_name,follower_count,following_count) `method` 

##### Summary

This servlet provides the retrieval of user followers and the accounts which the user is following.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| screen_name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The screen name of the Twitter user without "@" |
| follower_count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The maximum number of follower profiles to be fetched |
| following_count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The maximum number of following profiles to be fetched |

`var result = await loklak.user("loklak_app", <max-follower-count>, <max-following-count>);`

<a name='T-LoklakDotNet-LoklakSearchTerm'></a>
## LoklakSearchTerm 

##### Namespace

LoklakDotNet

##### Summary

Constructs a search term for the Loklak.search() method

##Contact
Contact [@aneeshd16](https://twitter.com/aneeshd16) on Twitter or at [me@aneesh.xyz](mailto:me@aneesh.xyz)
