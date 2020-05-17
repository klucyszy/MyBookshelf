const state = {
    isLoading: false
};

const mutations = {
    setLoading(state, loading) {
        state.isLoading = loading;
    }
};

const namespaced = true;

export default {
    namespaced,
    state,
    mutations
};