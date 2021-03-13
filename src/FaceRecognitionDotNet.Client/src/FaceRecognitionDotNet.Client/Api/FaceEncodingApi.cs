/*
 * FaceRecognitionDotNet Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using FaceRecognitionDotNet.Client.Client;
using FaceRecognitionDotNet.Client.Model;

namespace FaceRecognitionDotNet.Client.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFaceEncodingApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Returns an face feature data from image contains a human face.
        /// </summary>
        /// <exception cref="FaceRecognitionDotNet.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="image"> (optional)</param>
        /// <returns>Encoding</returns>
        Encoding FaceEncodingEncodingPost(Image image = default(Image));

        /// <summary>
        /// Returns an face feature data from image contains a human face.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FaceRecognitionDotNet.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="image"> (optional)</param>
        /// <returns>ApiResponse of Encoding</returns>
        ApiResponse<Encoding> FaceEncodingEncodingPostWithHttpInfo(Image image = default(Image));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFaceEncodingApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Returns an face feature data from image contains a human face.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FaceRecognitionDotNet.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="image"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Encoding</returns>
        System.Threading.Tasks.Task<Encoding> FaceEncodingEncodingPostAsync(Image image = default(Image), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Returns an face feature data from image contains a human face.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="FaceRecognitionDotNet.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="image"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Encoding)</returns>
        System.Threading.Tasks.Task<ApiResponse<Encoding>> FaceEncodingEncodingPostWithHttpInfoAsync(Image image = default(Image), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFaceEncodingApi : IFaceEncodingApiSync, IFaceEncodingApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class FaceEncodingApi : IFaceEncodingApi
    {
        private FaceRecognitionDotNet.Client.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceEncodingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FaceEncodingApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceEncodingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FaceEncodingApi(String basePath)
        {
            this.Configuration = FaceRecognitionDotNet.Client.Client.Configuration.MergeConfigurations(
                FaceRecognitionDotNet.Client.Client.GlobalConfiguration.Instance,
                new FaceRecognitionDotNet.Client.Client.Configuration { BasePath = basePath }
            );
            this.Client = new FaceRecognitionDotNet.Client.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new FaceRecognitionDotNet.Client.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = FaceRecognitionDotNet.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceEncodingApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public FaceEncodingApi(FaceRecognitionDotNet.Client.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = FaceRecognitionDotNet.Client.Client.Configuration.MergeConfigurations(
                FaceRecognitionDotNet.Client.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new FaceRecognitionDotNet.Client.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new FaceRecognitionDotNet.Client.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = FaceRecognitionDotNet.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceEncodingApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public FaceEncodingApi(FaceRecognitionDotNet.Client.Client.ISynchronousClient client, FaceRecognitionDotNet.Client.Client.IAsynchronousClient asyncClient, FaceRecognitionDotNet.Client.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = FaceRecognitionDotNet.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public FaceRecognitionDotNet.Client.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public FaceRecognitionDotNet.Client.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public FaceRecognitionDotNet.Client.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public FaceRecognitionDotNet.Client.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Returns an face feature data from image contains a human face. 
        /// </summary>
        /// <exception cref="FaceRecognitionDotNet.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="image"> (optional)</param>
        /// <returns>Encoding</returns>
        public Encoding FaceEncodingEncodingPost(Image image = default(Image))
        {
            FaceRecognitionDotNet.Client.Client.ApiResponse<Encoding> localVarResponse = FaceEncodingEncodingPostWithHttpInfo(image);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Returns an face feature data from image contains a human face. 
        /// </summary>
        /// <exception cref="FaceRecognitionDotNet.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="image"> (optional)</param>
        /// <returns>ApiResponse of Encoding</returns>
        public FaceRecognitionDotNet.Client.Client.ApiResponse<Encoding> FaceEncodingEncodingPostWithHttpInfo(Image image = default(Image))
        {
            FaceRecognitionDotNet.Client.Client.RequestOptions localVarRequestOptions = new FaceRecognitionDotNet.Client.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = FaceRecognitionDotNet.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = FaceRecognitionDotNet.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = image;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Encoding>("/FaceEncoding/Encoding", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FaceEncodingEncodingPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Returns an face feature data from image contains a human face. 
        /// </summary>
        /// <exception cref="FaceRecognitionDotNet.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="image"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Encoding</returns>
        public async System.Threading.Tasks.Task<Encoding> FaceEncodingEncodingPostAsync(Image image = default(Image), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            FaceRecognitionDotNet.Client.Client.ApiResponse<Encoding> localVarResponse = await FaceEncodingEncodingPostWithHttpInfoAsync(image, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Returns an face feature data from image contains a human face. 
        /// </summary>
        /// <exception cref="FaceRecognitionDotNet.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="image"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Encoding)</returns>
        public async System.Threading.Tasks.Task<FaceRecognitionDotNet.Client.Client.ApiResponse<Encoding>> FaceEncodingEncodingPostWithHttpInfoAsync(Image image = default(Image), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            FaceRecognitionDotNet.Client.Client.RequestOptions localVarRequestOptions = new FaceRecognitionDotNet.Client.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = FaceRecognitionDotNet.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = FaceRecognitionDotNet.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = image;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Encoding>("/FaceEncoding/Encoding", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FaceEncodingEncodingPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
