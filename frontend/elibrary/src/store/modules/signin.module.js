const state = {
    isSignedIn: false,
    id_token: null,
    user: {}
};

const getters = {
    signedIn: state => state.isSignedIn,
    idToken: state => state.id_token,
    user: state => state.user
};

const actions = {
    logIn(context) {
        context.commit('loading/setLoading', true, {root: true});
        this._vm.$gAuth
        .getAuthCode()
        .then(authCode => {
            this._vm.axios.post('/api/authorize/google', {
                'authCode': authCode
            })
            .then((res) => {
                context.commit('SET_ID_TOKEN_STATE', "Bearer " + res.data.token);
                context.commit('SET_SIGN_IN_STATE', true);
                context.commit('alert/alertSuccess', "You are authorized", {root: true});
                context.commit('loading/setLoading', false, {root: true});
            })
            .catch((err) => {
                let errMessage = "Authorization failed: " + err; 
                console.log(errMessage)
                context.commit('SET_SIGN_IN_STATE', false);
                context.commit('alert/alertError', errMessage, { root: true });
                context.commit('loading/setLoading', false, {root: true});
            });
        })
        .catch(err => {
            let errMessage = "Authorization failed: " + err; 
            console.log(errMessage)
            context.commit('SET_SIGN_IN_STATE', false);
            context.commit('alert/alertError', errMessage, { root: true });
            context.commit('loading/setLoading', false, {root: true});
        });
    },
    logOut(context){
        context.commit('loading/setLoading', true, {root: true});
        this._vm.$gAuth
        .signOut()
        .then(() =>{
            context.commit('SET_USER_STATE', {});
            context.commit('SET_ID_TOKEN_STATE', null);
            context.commit('SET_SIGN_IN_STATE', false);

            context.commit('alert/alertSuccess', "You are successfullt sign out", {root: true});
            context.commit('loading/setLoading', false, {root: true});
        })
        .catch(error => {
            console.log(error);
            context.commit('loading/setLoading', false, {root: true});
          });
    },
};

const mutations = {
    SET_SIGN_IN_STATE(state, signInState) {
        state.isSignedIn = signInState;
    },
    SET_ID_TOKEN_STATE(state, idToken) {
        state.id_token = idToken;
    },
    SET_USER_STATE(state, user) {
        state.user = user;
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