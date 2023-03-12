import * as actions from './actionType'
import axios from "axios";
import { courseApi } from "./utils/Services";

export const onGetCourse = () => {
    return (dispatch) => {
        axios.get(courseApi+"/GetCourse").then((res) => {
            dispatch(
                ((data) => {
                  return {
                    type: actions.GET_COURSE_DATA,
                    payload: {
                      httpResponse: data,
                    },
                  };
                })(res.data)
              );
        }).catch((error) => {
            console.log(error);
        })
    }
}

export const onDeleteCourse = (id) => {
  return (dispatch) => {
      axios.delete(courseApi+"/DeleteCourse?id="+id).then((res) => {
        dispatch(onGetCourse())
      }).catch((error) => {
          console.log(error);
      })
  }
}

export const onPostData = (data) => {
  return (dispatch) => {
      axios.post(courseApi+"/PostCourse", data).then((res) => {
        dispatch(onGetCourse())
      }).catch((error) => {
          console.log(error);
      })
  }
}