const state = {
    selectedCategories: [],
    books: [],
    categories: []
};

const getters = {
    selectedCategoriesIds: function() {
        let selectedCategoriesArray = [];
        for(let i = 0; i < state.selectedCategories.length; i++) {
            selectedCategoriesArray.push(state.selectedCategories[i].id);
        }
        return selectedCategoriesArray;
    },
    books: state => state.books,
    categories: state => state.categories,
};

const actions = {
    setCategories: function(context, categories) {
        context.commit('setSelectedCategories', categories);
        context.dispatch('getBooks');
    },
    getBooks: function(context) {
        context.commit('loading/setLoading', true, {root: true});
        const qs = require('qs');
        let params = {};
        let bookshelfIds = context.rootGetters['search/selectedCategoriesIds'];
        if (bookshelfIds.length > 0)
            params.BookshelfIds = bookshelfIds;

        this._vm.axios.get('/api/books', {
            params: params,
            headers: {
                Authorization: context.rootState.signin.id_token
            },
            paramsSerializer: function(params) {
                return qs.stringify(params, {arrayFormat: 'repeat'})
            },
        })
        .then((res) => {
            if (res && res.data && Array.isArray(res.data.volumes)) {
                context.commit('setBooks', res.data.volumes);
                context.commit('loading/setLoading', false, {root: true});
            }
        })
        .catch((err) => {
            console.log(err);
            context.commit('alert/alertError', err, { root: true });
            context.commit('loading/setLoading', false, {root: true});
        })
    }
};

const mutations = {
    setSelectedCategories(state, selectedCategories) {
        state.selectedCategories = selectedCategories;

    },
    setBooks(state, books) {
        state.books = books;
    },
    setCategories(state, categories) {
        state.categories = categories;
    }
};

const namespaced = true;

export default {
    namespaced,
    state,
    getters,
    actions,
    mutations
};