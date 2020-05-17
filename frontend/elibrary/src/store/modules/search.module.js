const state = {
    selectedCategories: [],
    books: []
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
};

const actions = {
    setCategories: function(context, categories) {
        context.commit('setSelectedCategories', categories);
        context.dispatch('getBooks');
    },
    getBooks: function(context) {
        
        this._vm.axios.get('/api/books', {
            params: {
                BookshelfIds: context.rootGetters['search/selectedCategoriesIds']  + ''
            },
            headers: {
                Authorization: context.rootState.signin.id_token
            },
        })
        .then((res) => {
            if (res && res.data && Array.isArray(res.data.volumes)) {
                context.commit('setBooks', res.data.volumes);
            }
        })
        .catch((err) => {
            console.log(err);
        })
    }
};

const mutations = {
    setSelectedCategories(state, selectedCategories) {
        state.selectedCategories = selectedCategories;

    },
    setBooks(state, books) {
        state.books = books;
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