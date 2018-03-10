import { GetRequest, PostRequest } from './requestService';

export async function loadFiveTheMostPopularBicycles() {
    try {
        let response = await GetRequest('/api/Value/GetBicycles');
        return response.json();
    } catch (err) {
        throw (err);
    }
}

export async function loadProductDetails(productId) {
    try {
        let response = await PostRequest(productId, '/api/Value/GetProductDetails');
        return response.json();
    } catch (err) {
        throw (err);
    }
}

export async function findProductsByName(productName) {
    try {
        let response = await PostRequest(productName, '/api/Value/GetProductsByName');
        return response.json();
    } catch (err) {
        throw (err);
    }
}

export async function deleteProduct(productId) {
    try {
        return await PostRequest(productId, '/api/Value/DeleteProduct');
    } catch (err) {
        throw (err);
    }
}

export async function updateProduct(product) {
    try {
        await PostRequest(product, '/api/Value/EditProduct');
        return product;
    } catch (err) {
        throw (err);
    }
}

export async function addProduct(newProduct) {
    try {
        let response = await PostRequest(newProduct, '/api/Value/AddProduct');
        return response.json();
    } catch (err) {
        throw (err);
    }
}

export async function loadProductSubcategories() {
    try {
        let response = await GetRequest('/api/Categories/GetAllProductSubCategories');
        return response.json();
    } catch (err) {
        throw (err);
    }
}