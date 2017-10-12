package Student;

public class Student {
	//Fields
private String firstName;
private String lastName;
private double grade;
private String department;

//Constructor
public Student(String fname, String lname, double gr, String dept){
	setFirstName(fname);
	setLastName(lname);
	setGrade(gr);
	setDepartment(dept);
}

//Getters and Setters
public String getFirstName() {
	return firstName;
}

public void setFirstName(String firstName) {
	this.firstName = firstName;
}

public String getLastName() {
	return lastName;
}

public void setLastName(String lastName) {
	this.lastName = lastName;
}

public double getGrade() {
	return grade;
}

public void setGrade(double grade) {
	this.grade = grade;
}

public String getDepartment() {
	return department;
}

public void setDepartment(String department) {
	this.department = department;
}

public String getName(){
	return (getFirstName() +" " + getLastName()); 
}

//toString, hashCode and equals methods
@Override
public int hashCode() {
	final int prime = 31;
	int result = 1;
	result = prime * result + ((department == null) ? 0 : department.hashCode());
	result = prime * result + ((firstName == null) ? 0 : firstName.hashCode());
	long temp;
	temp = Double.doubleToLongBits(grade);
	result = prime * result + (int) (temp ^ (temp >>> 32));
	result = prime * result + ((lastName == null) ? 0 : lastName.hashCode());
	return result;
}

@Override
public boolean equals(Object obj) {
	if (this == obj)
		return true;
	if (obj == null)
		return false;
	if (getClass() != obj.getClass())
		return false;
	Student other = (Student) obj;
	if (department == null) {
		if (other.department != null)
			return false;
	} else if (!department.equals(other.department))
		return false;
	if (firstName == null) {
		if (other.firstName != null)
			return false;
	} else if (!firstName.equals(other.firstName))
		return false;
	if (Double.doubleToLongBits(grade) != Double.doubleToLongBits(other.grade))
		return false;
	if (lastName == null) {
		if (other.lastName != null)
			return false;
	} else if (!lastName.equals(other.lastName))
		return false;
	return true;
}

@Override
public String toString() {
	return firstName + "  \t  " + lastName +"  \t  "+ grade +"  \t  "+ department + "\n";
}



}
