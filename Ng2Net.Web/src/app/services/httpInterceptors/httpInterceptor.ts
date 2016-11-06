import { Interceptor, InterceptedRequest, InterceptedResponse } from 'ng2-interceptors';
import { environment } from '../../../environments/environment';
import { CookieService } from 'angular2-cookie/services/cookies.service';

export class ServerURLInterceptor implements Interceptor {
    constructor(private cookieService: CookieService) { }

    public interceptBefore(request: InterceptedRequest): InterceptedRequest {
        let authToken = this.cookieService.get('auth_token');

        if (authToken !== '') {
            request.options.headers.append('Authorization', 'Bearer ' + authToken);
        }
        request.url = environment.apiUrl + request.url;
        return request;
        /*
          You can return:
            - Request: The modified request
            - Nothing: For convenience: It's just like returning the request
            - <any>(Observable.throw("cancelled")): Cancels the request, interrupting it
            from the pipeline, and calling back 'interceptAfter' in backwards order of those
            interceptors that got called up to this point.
        */
    }

    public interceptAfter(response: InterceptedResponse): InterceptedResponse {
        // Do whatever with response: get info or edit it

        return response;
        /*
          You can return:
            - Response: The modified response
            - Nothing: For convenience: It's just like returning the response
        */
    }
}
