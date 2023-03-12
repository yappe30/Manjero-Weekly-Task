import * as actions from "./actionType";

const initState = {
    courseData: [],
}

export const reducer = (state = initState, action) => {
    
    switch (action.type) {
        case actions.GET_COURSE_DATA:
            return { ...state, courseData: action.payload.httpResponse }
        default:
            return state
    }
}

export default reducer;