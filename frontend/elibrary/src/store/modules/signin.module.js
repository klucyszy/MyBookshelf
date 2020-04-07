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
        this._vm.$gAuth
        .signIn()
        .then(GoogleUser => {
            context.commit('SET_USER_STATE', GoogleUser.Qt);
            context.commit('SET_ID_TOKEN_STATE', GoogleUser.uc.id_token);
        })
        .catch(err => {
            console.log("Authorization failed: " + err)
        })
        .finally(() => {
            context.commit('SET_SIGN_IN_STATE', this._vm.$gAuth.isAuthorized);
        });
    },
    logOut(context){
        this._vm.$gAuth
        .signOut()
        .then(() =>{
            context.commit('SET_USER_STATE', {});
            context.commit('SET_ID_TOKEN_STATE', null);
            context.commit('SET_SIGN_IN_STATE', false);
        })
        .catch(error => {
            console.log(error);
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