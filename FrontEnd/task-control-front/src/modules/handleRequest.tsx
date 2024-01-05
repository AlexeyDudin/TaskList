export enum RequestMethod {
  GET = "GET",
  POST = "POST",
  DELETE = "DELETE",
}

const headers = {
  "Content-type": "application/json",
  "X-Requested-With": "XMLHttpRequest",
};

async function fetchData(url: string, method: RequestMethod, params?: Object) {
  let props: Object = {
    method,
    headers,
  };
  switch (method) {
    case RequestMethod.GET:
      if (params) {
        const tempUrl = new URL(url);

        Object.keys(params).forEach((key) =>
          // @ts-ignore
          tempUrl.searchParams.append(key, params[key])
        );
        url = url + "?" + tempUrl.searchParams.toString();
      }
      break;
    case RequestMethod.POST:
    case RequestMethod.DELETE:
      props = {
        ...props,
        body: JSON.stringify(params),
      };
      break;
  }

  return fetch(url, props).then((response) => {
    if (response.redirected) {
      window.open(response.url, "_self");
      return undefined;
    }
    if (response.ok) {
      return response.json();
    }
    return response;
  });
}

export { fetchData };
