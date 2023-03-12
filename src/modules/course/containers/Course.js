import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import AddCourseModal from '../components/AddCourseModal';
import { onGetCourse, onDeleteCourse } from '../../action';
import "./CourseStyle.css";


const Course = () => {
    const dispatch = useDispatch();

    const courseData = useSelector(state => state.courseData);

    console.log(courseData);

    useEffect(() => {
        dispatch(onGetCourse());
    }, [])

    const deleteData = (e) => {
    
        let id = e.target.id;
        dispatch(onDeleteCourse(id));

    }

    

    return (
        <>
            <h2>Sample Crud With API</h2>
            <br />
            <AddCourseModal />
            <br />
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Durations</th>
                        <th>Date Start</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {courseData.length ? (
                        courseData.map((item, index) => {
                            return (
                                <tr key={index}>
                                    <td>{item.courseName}</td>
                                    <td>{item.courseName}</td>
                                    <td>{item.courseName}</td>
                                    <td>{item.courseName}</td>
                                    <td><button id={item.courseId} onClick={deleteData}>Delete</button></td>
                                </tr>
                            );
                        })
                    ) : (
                        <tr>
                            <td colSpan="5" style={{textAlign:'center'}}>No Available Data</td>
                        </tr>
                    )}


                </tbody>
            </table>
        </>
    );
};

export default Course;