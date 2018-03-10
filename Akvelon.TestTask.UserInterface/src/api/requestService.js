import apiUrl from './url_config';

export function PostRequest(data, methodUrl) {
    let headers = { 'Content-Type': 'application/json' };
    return fetch(`${apiUrl.baseUrl}${methodUrl}`, {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(data)
    });
}

export function GetRequest(methodUrl) {
    return fetch(`${apiUrl.baseUrl}${methodUrl}`);
}