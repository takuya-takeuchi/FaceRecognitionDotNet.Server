# FaceRecognitionDotNet.Client.Api.FaceRegistrationApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**FaceRegistrationRegisterPost**](FaceRegistrationApi.md#faceregistrationregisterpost) | **POST** /FaceRegistration/Register | Register person data.


<a name="faceregistrationregisterpost"></a>
# **FaceRegistrationRegisterPost**
> void FaceRegistrationRegisterPost (Registration registration = null)

Register person data.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Client.Client;
using FaceRecognitionDotNet.Client.Model;

namespace Example
{
    public class FaceRegistrationRegisterPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new FaceRegistrationApi(config);
            var registration = new Registration(); // Registration |  (optional) 

            try
            {
                // Register person data.
                apiInstance.FaceRegistrationRegisterPost(registration);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FaceRegistrationApi.FaceRegistrationRegisterPost: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **registration** | [**Registration**](Registration.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **429** | Client Error |  -  |
| **500** | Server Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

