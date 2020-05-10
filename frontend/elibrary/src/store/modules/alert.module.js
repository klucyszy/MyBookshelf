const state = {
    alerts: [],
    alert: {
        message: "",
        type: "success"
    }
};

const getters = {
};

const actions = {
};

const mutations = {
    alertError(state, errorMessage) {
        state.alert = {
            type: "error",
            message: errorMessage
        }
    },
    alertSuccess(state, successMessage) {
        state.alert = {
            type: "success",
            message: successMessage
        }
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